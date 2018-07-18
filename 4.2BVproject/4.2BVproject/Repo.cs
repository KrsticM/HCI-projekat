using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace _4._2BVproject
{
    [DataContract]
    public class Repo
    {
        [DataMember]
        public ObservableCollection<TipVrste> TipoviVrsta
        {
            get;
            set;
        }

        [DataMember]
        public ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }

        [DataMember]
        public ObservableCollection<UgrozenaVrsta> ugrozeneVrste
        {
            get;
            set;
        }

        [DataMember]
        public ObservableCollection<UgrozenaVrsta> naMapi
        {
            get;
            set;
        }

    }
}
