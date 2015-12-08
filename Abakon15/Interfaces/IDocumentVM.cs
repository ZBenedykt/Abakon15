using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbakonDataModel;

namespace Abakon15.Interfaces
{

    public interface IPrzyrzadPomiarowy
    {
        PrzyrzadPomiarowy CurrentPrzyrzadPomiarowy
        {
            get;
            set;
        }


    }

    public interface ITask
    {
        ITask CurrentTask
        {
            get;
            set;
        }
    }

    public interface IPartner
    {
        IPartner CurrentPartner
        {
            get;
            set;
        }
    }

    public interface IPerson
    {
        IPerson CurrentPerson
        {
            get;
            set;
        }
    }

    public interface IDocument
    {
        IDocument CurrentDocument
        {
            get;
            set;
        }
    }

}
