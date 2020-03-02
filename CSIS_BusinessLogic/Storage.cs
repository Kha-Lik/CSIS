using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace CSIS_BusinessLogic
{
    [DataContract]
    public class Storage : IEnumerable<Cosmetic>
    {
        [DataMember]
        private ObservableCollection<Cosmetic> _cosmetics = new ObservableCollection<Cosmetic>();

        public void AddCosmetic(string name, int units, int price, int delivTime)
        {
            _cosmetics.Add(new Cosmetic(name, units, price, delivTime));
        }
        
        public void AddCosmetic(string name, int units, int price, int delivTime, int shelfLife, int usingTime, bool isEnding = false)
        {
            _cosmetics.Add(new CosmeticUsedSlowly(name, units, price, delivTime, shelfLife, usingTime, isEnding));
        }

        public ObservableCollection<Cosmetic> GetCosmetics() => _cosmetics;
        public void AddCosmetic(Cosmetic cosmetic) => _cosmetics.Add(cosmetic);
        public IEnumerator<Cosmetic> GetEnumerator() => _cosmetics.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}