namespace Task12
{
    public class DoubleItem<T>
    {
        public T Data { get; set; }
        public DoubleItem<T> Previous { get; set; }
        public DoubleItem<T> Next { get; set; }

        public DoubleItem()
        {

        }

        public DoubleItem(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}