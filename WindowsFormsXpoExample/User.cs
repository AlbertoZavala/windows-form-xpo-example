using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace WindowsFormsXpoExample {
    public class User : XPObject {

        /// <summary>
        /// Enum definition for User status.
        /// </summary>
        public enum EStatus {
            Enable,
            Disable
        }

        /// <summary>
        /// User Name
        /// </summary>
        private string mUserName;

        /// <summary>
        /// Password
        /// </summary>
        private string mPassword;

        /// <summary>
        /// Indicate if user is enabled or disabled.
        /// </summary>
        private EStatus mStatus;

        /// <summary>
        /// Constructor that get the UnitOfWork and pass it to base clase
        /// </summary>
        /// <param name="unitOfWork"></param>
        public User(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public string UserName {
            get { return mUserName; }
            set { SetPropertyValue(nameof(UserName), ref mUserName, value); }
        }

        public string Password {
            get { return mPassword; }
            set { SetPropertyValue(nameof(Password), ref mPassword, value); }
        }

        public EStatus Status {
            get { return mStatus; }
            set { SetPropertyValue(nameof(mStatus), ref mStatus, value); }
        }

        public static class Properties {
            public static OperandProperty Oid {
                get { return new OperandProperty(nameof(Oid)); }
            }

            public static OperandProperty UserName {
                get { return new OperandProperty(nameof(UserName)); }
            }

            public static OperandProperty Password {
                get { return new OperandProperty(nameof(Password)); }
            }

            public static OperandProperty Status {
                get { return new OperandProperty(nameof(Status)); }
            }
        }
    }
}
