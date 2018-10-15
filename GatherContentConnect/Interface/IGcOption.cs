namespace GatherContentConnect.Interface
{
    public interface IGcOption
    {
        //Specifies the label.
        string Label { get; set; }
        //Specifies if selected or not.
        bool IsSelected { get; set; }
        //Specifies the name of the option.
        string Name { get; set; }

    }
}
