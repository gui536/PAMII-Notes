namespace Notes;

public partial class NotePage : ContentPage
{
    string _filepath = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
	
    public NotePage()
	{
		InitializeComponent();

        if ( File.Exists(_filepath))
        {
            TextEditor.Text = File.ReadAllText(_filepath);
        }
	}

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        File.WriteAllText(_filepath, TextEditor.Text);
        await DisplayAlert("Sucesso", "Arquivo criado com sucesso", "OK");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(_filepath))
        {
            File.Delete(_filepath);
            await DisplayAlert("Sucesso", "Arquivo deletado com sucesso", "OK");
            TextEditor.Text = "";
        }
        else
        {
            await DisplayAlert("Arquivo não encontrado", "Nenhum arquivo foi encontrado", "OK");
        }
    }
}