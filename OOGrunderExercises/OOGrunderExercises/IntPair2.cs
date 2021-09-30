using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOGrunderExercises
{
    class IntPair2
    {
        private int _value1;
        private int _value2;

        public int Value1
        {
            get
            {
                return _value1;
            }
            set
            {
                _value1 = value;
            }
        }

        public int Value2
        {
            get
            {
                return _value2;
            }
            set
            {
                _value2 = value;
            }
        }

        public double Average
        {
            get
            {
                return (_value1 + _value2) / 2.0; ;
            }
        }

        public IntPair2(int value1, int value2)
        {
            _value1 = value1;
            _value2 = value2;
        }

        public int GetValue1()
        {
            return _value1;
        }
        public int GetValue2()
        {
            return _value2;
        }

        public void SetValue1(int value1)
        {
            _value1 = value1;
        }
        public void SetValue2(int value2)
        {
            _value2 = value2;
        }

    }
}
