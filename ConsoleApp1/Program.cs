namespace Dialog
{

    public interface IButton
    {
        void render();
        void OnClick(Action click);
    }

    public class WindowsButton : IButton
    {
        public void OnClick(Action click)
        {
            //OnClick
        }

        public void render() { }
    }

    public class HtmlButton : IButton
    {
        public void OnClick(Action click)
        {
            //OnCLick
        }

        public void render() { }
    }

    public abstract class Dialog
    {
        public void render()
        {
            IButton okButton = CreateButton();
            okButton.OnClick(CloseDialog);
            okButton.render();
        }

        private void CloseDialog()
        {
            //CLoseDialog
        }

        public abstract IButton CreateButton();
    }

    public class WindowsDialog : Dialog
    {
        public override IButton CreateButton()
        {
            return new WindowsButton();
        }
    }

    public class WebDialog : Dialog
    {
        public override IButton CreateButton()
        {
            return new HtmlButton();
        }
    }

    public class Creator
    {
        public Dialog CreateDialog(string platform)
        {
            Dialog dialog;

            switch (platform.ToLower())
            {
                case "windows":
                    dialog = new WindowsDialog();
                    break;
                case "web":
                    dialog = new WebDialog();
                    break;
                default:
                    throw new ArgumentException("Invalid platform specified");
            }

            return dialog;
        }
    }


    internal class Program
    {
        private static void Main(string[] args)
        {
            Creator dialogCreator = new Creator();
            Dialog windowsDialog = dialogCreator.CreateDialog("windows");
            windowsDialog.render();
            Dialog webDialog = dialogCreator.CreateDialog("web");
            webDialog.render();
        }
    }
}
