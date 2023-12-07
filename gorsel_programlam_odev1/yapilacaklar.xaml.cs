using System.Collections.ObjectModel;

namespace gorsel_programlam_odev1;

public partial class yapilacaklar : ContentPage
{
    private ObservableCollection<string> notes = new ObservableCollection<string>();
 

    public yapilacaklar()
    {
        InitializeComponent();
        NotePicker.ItemsSource = notes;


    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        string note = NoteEditor.Text;

        if (string.IsNullOrWhiteSpace(note))
        {
            // Notify the user that the note is empty
            DisplayAlert("Error", "Note cannot be empty", "OK");
            return;
        }

        if (NotePicker.SelectedIndex != -1)
        {
           
            int selectedIndex = NotePicker.SelectedIndex;
            notes[selectedIndex] = note;

            
            RefreshNotePicker();
        }
        else
        {
            
            notes.Add(note);

            RefreshNotePicker();
        }

   
        NoteEditor.Text = string.Empty;
        
        NotePicker.SelectedIndex = -1;
    }

    private void RefreshNotePicker()
    {
       
        NotePicker.ItemsSource = notes;
    }




    private void OnEditClicked(object sender, EventArgs e)
    {
       
        NoteEditor.IsEnabled = true;

       
        NoteEditor.Text = string.Empty;

      
        NotePicker.SelectedIndex = -1;

        
        NotePicker.ItemsSource = notes;

    
        NotePicker.SelectedIndexChanged += OnNotePickerSelectedIndexChanged;
    }

    private void OnNotePickerSelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (NotePicker.SelectedIndex != -1)
        {
            NoteEditor.Text = notes[NotePicker.SelectedIndex];
        }
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        if (NotePicker.SelectedIndex != -1)
        {
           
            notes.RemoveAt(NotePicker.SelectedIndex);

           
            NoteEditor.Text = string.Empty;
            
            NotePicker.SelectedIndex = -1;
        }
    }
}


 




