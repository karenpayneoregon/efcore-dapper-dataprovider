using WorkingWithSqlServerImages.Classes;

namespace WorkingWithSqlServerImages;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void InsertClientButton_Click(object sender, EventArgs e)
    {
        if (TruncateCheckBox.Checked)
        {
            TruncateTable();
        }
        ClientOperations.InsertImage(File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Images", "bag.png")));
    }

    private void ReadClientButton_Click(object sender, EventArgs e)
    {
        var (container, success) = ClientOperations.ReadImage(1);
        if (success)
        {
            PhotoPictureBox.Image = container.Picture;
        }
        else
        {
            PhotoPictureBox.Image = null;
            MessageBox.Show(@"Not found");
        }
        
    }

    private void InsertDapperButton_Click(object sender, EventArgs e)
    {
        if (TruncateCheckBox.Checked)
        {
            TruncateTable();
        }

        DapperOperations.InsertImage(File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Bootstrap.png")));
    }

    private void ReadDapperButton_Click(object sender, EventArgs e)
    {
        var (container, success) = DapperOperations.ReadImage(1);
        if (success)
        {
            PhotoPictureBox.Image = container.Picture;
        }
        else
        {
            PhotoPictureBox.Image = null;
            MessageBox.Show(@"Not found");
        }
    }

    private void InsertEntityButton_Click(object sender, EventArgs e)
    {
        if (TruncateCheckBox.Checked)
        {
            TruncateTable();
        }

        EntityOperations.InsertImage(File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Mitata.png")));
    }

    private void ReadEntityButton_Click(object sender, EventArgs e)
    {
        var (container, success) = EntityOperations.ReadImage(1);
        if (success)
        {
            PhotoPictureBox.Image = container.Picture;
        }
        else
        {
            PhotoPictureBox.Image = null;
            MessageBox.Show(@"Not found");
        }
    }

    private void TruncateTable()
    {
        PhotoPictureBox.Image = null;
        ClientOperations.TruncateTable();
    }
}
