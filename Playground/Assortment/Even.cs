using System.Collections;

namespace Assortment
{
    public class Even : IEnumerable
    {
        public static bool IsEven(int number)
        {
            bool result;

            if (number % 2 == 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}