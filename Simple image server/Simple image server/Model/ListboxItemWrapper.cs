namespace Simple_image_server.Model
{
    public class ListboxItemWrapper
    {
        public string Name { get; set; }
        public object Tag { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
