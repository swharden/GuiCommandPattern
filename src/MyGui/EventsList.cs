using MyBackend;

namespace MyGui;
public partial class EventsList : Form
{
    public EventsList(IEnumerable<UiEvent> events)
    {
        InitializeComponent();

        foreach (UiEvent e in events)
        {
            listBox1.Items.Add(e.ToString());
        }
    }
}
