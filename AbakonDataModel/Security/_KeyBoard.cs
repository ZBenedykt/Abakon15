using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AbakonDataModel.DataAccess;

namespace AbakonDataModel
{
    [Table("_KeyBoard")]
    public class _KeyBoardKey
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _KeyBoardId { get; set; }
        public byte _KeyLp { get; set; }
        public String _KeyValue { get; set; }



        public static IEnumerable<_KeyBoardKey> Load(PgSqlDBContext dbContext = null)
        {
            return _KeyBoardKeyInDB.Load(dbContext);
        }

        public static _KeyBoardKey AddToContext(_KeyBoardKey newRec, PgSqlDBContext dbContext = null)
        {
            return _KeyBoardKeyInDB.AddToContext(newRec, dbContext);
        }

        public static void Delete(_KeyBoardKey delRec, PgSqlDBContext dbContext = null)
        {
            _KeyBoardKeyInDB.Delete(delRec, dbContext);
        }


        public static _KeyBoardKey Create(PgSqlDBContext dbContext = null)
        {
            _KeyBoardKey newRec = new _KeyBoardKey();
            return _KeyBoardKeyInDB.AddToContext(newRec, dbContext);
        }

        public static void SetDefault(PgSqlDBContext dbContext = null)
        {
            string[] charList = { "±", "²", " ³", "°", "′", "″", "α", "β", "γ", "δ", "ε", "ζ", "η", "θ", "μ", "ξ", "π", "ρ", "ς", "σ", "φ", "ψ", "ω", "∆", "Ω", "∑", "∞", "‰" };
            byte lp = 0;
            foreach (var item in charList)
            {
                _KeyBoardKey newKey = new _KeyBoardKey();
                newKey._KeyLp = lp++;
                newKey._KeyValue = item;
                _KeyBoardKeyInDB.AddToContext(newKey, dbContext);
            }
            _KeyBoardKeyInDB.SaveChanges(dbContext);
        }
    }
}
