using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abakon15WPF.Infrastructure
{
    public class StateOfExecution
    {
        protected bool m_OperationOK = true;
        public StateOfExecution()
        {
        }
        public StateOfExecution(Exception e)
        {
            Exception = e;
        }

        public StateOfExecution(string exceptionMsg)
        {
            this.ExceptionMsg = exceptionMsg;
        }

        Exception m_Exception;
        /// <summary>
        /// Obiekt Exception jesli w metodzie przechwycono wyjątek;
        /// </summary>
        public Exception Exception
        {
            get { return m_Exception; }
            set
            {
                m_Exception = value;
                if (m_Exception != null)
                {
                    OperationOK = false;
                }

            }
        }

        public bool OperationOK
        {
            get { return m_OperationOK; }
            set
            {
                m_OperationOK = value;
                if (m_Exception == null && value == false)
                {
                    this.Exception = new Exception("_StateOfExecutionError".Translate());
                }
            }
        }


        public string ExceptionMsg
        {
            get
            {
                if (m_Exception != null)
                {
                    return m_Exception.Message + " " + (m_Exception.InnerException != null ? ("\n\r" + m_Exception.InnerException.Message) : "");
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    OperationOK = false;
                    this.CreateException(value);
                }
            }
        }

        public Exception CreateException(string exceptionMessage)
        {
            this.Exception = new Exception(exceptionMessage);
            return m_Exception;
        }
    }

}
