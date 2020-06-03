namespace EasyForm
{
    public class Option<T>
        where T :struct
    { 
        public string Label { get; set; }
        public T Value { get; set; }
    }
}
