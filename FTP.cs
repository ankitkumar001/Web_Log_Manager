using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WSLA
{
    /// <summary>
    /// Summary description for FTP.
    /// </summary>
    public class FTPException : ApplicationException
    {
        public String MessageText;

        public FTPException(string message)
            : base(message)
        {
        }
    }

    public class FTP
    {
        private FTP()	// there's no need to instantiate objects of this class.
        {
        }

        public FTPException FTPException
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public PU.ProcessUtils ProcessUtils
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Globals Globals
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern uint InternetOpen(uint lpszAgent,
                                               uint dwAccessType,
                                               uint lpszProxyName,
                                               string lpszProxyBypass,
                                               uint dwFlags);

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern uint InternetConnect(uint hInternet,
                                                  string lpszServerName,
                                                  int nServerPort,
                                                  string lpszUsername,
                                                  string lpszPassword,
                                                  uint dwService,
                                                  uint dwFlags,
                                                  ref uint dwContext);

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern int FtpGetFile(uint hConnect,
                                            string lpszRemoteFile,
                                            string lpszNewFile,
                                            int fFailIfExists,
                                            uint dwFlagsAndAttributes,
                                            uint dwFlags,
                                            ref uint dwContext);

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern int InternetCloseHandle(uint hInternet);

        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();

        [DllImport("kernel32.dll")]
        public static extern uint FormatMessage(uint dwFlags,
                                                uint lpSource,
                                                uint dwMessageId,
                                                uint dwLanguageId,
                                                byte[] lpBuffer,
                                                uint nSize,
                                                uint Arguments);

        // Return text error message from WinInet error.

        private static String GetLastErrorMessage(uint LastError)
        {
            String Result = "";

            if (LastError != 0)
            {
                uint FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
                uint FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;

                byte[] Buffer = new Byte[1024];

                uint Chars = FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
                                           0,
                                           (uint)LastError,
                                           0,
                                           Buffer,
                                           (uint)Buffer.Length,
                                           0);

                for (int i = 0; i < (int)Chars; i++)
                {
                    Result += (char)Buffer[i];
                }
            }

            return Result;
        }

        // If an error has occurred with a WinInet API call, retrieve the
        // error message text, close the Internet session handle, and throw
        // an FTPException.

        private static void ProcessError(String DefaultMessage, uint hInternet)
        {
            uint LastError = GetLastError();

            if (LastError != 0)
            {
                String Message = GetLastErrorMessage(LastError);

                if (Message.Length == 0)
                {
                    Message = DefaultMessage;
                }

                InternetCloseHandle(hInternet);

                throw new FTPException(DefaultMessage);
            }
        }

        // Download a file via FTP and store it in the specified FileName and FilePath.

        public static void GetFtpFile(String FTPServer, String User, String Password, String FileName, String FilePath, bool Text)
        {
            // Get an Internet session handle.
            uint hInternet = InternetOpen(0, 1, 0, "", 0);
            ProcessError("InternetOpen failed", hInternet);

            if (hInternet != 0)
            {
                uint Context = 0;

                // Connect to the specified FTP server.
                hInternet = InternetConnect(hInternet, FTPServer, 21,
                                            User, Password,
                                            1, 0, ref Context);
                ProcessError("InternetConnect failed", hInternet);

                if (hInternet != 0)
                {
                    // Download the file via FTP.
                    int Status = FtpGetFile(hInternet,
                                            FileName,
                                            FilePath,
                                            0,
                                            0,
                                            (uint)(Text ? 0x00000001 : 0x00000002),
                                            ref Context);
                    ProcessError("FtpGetFile failed", hInternet);

                    if (Status == 0)
                    {
                        InternetCloseHandle(hInternet);
                        throw new FTPException("cannot download remote file " + FileName + " to " + FilePath);
                    }
                }
                else
                {
                    InternetCloseHandle(hInternet);
                    throw new FTPException("InternetConnect failed");
                }

                if (InternetCloseHandle(hInternet) == 0)
                {
                    throw new FTPException("InternetCloseHandle failed");
                }
            }
            else
            {
                InternetCloseHandle(hInternet);
                throw new FTPException("InternetConnect failed");
            }
        }
    }
}
