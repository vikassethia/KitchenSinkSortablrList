using System;
using Starcounter;

namespace KitchenSink
{
    partial class CallbackPage : Page
    {
        protected int timeout = 1000;

        protected override void OnData()
        {
            base.OnData();

            this.Items.Add();
            this.Items.Add();
            this.Items.Add();
            this.Items.Add();
        }

        protected void Handle(Input.SaveClick Action)
        {
            Action.Cancel();
            System.Threading.Thread.CurrentThread.Join(timeout);
        }

        protected void Handle(Input.SaveAndSpinClick Action)
        {
            Action.Cancel();
            System.Threading.Thread.CurrentThread.Join(timeout);
        }

        protected void Handle(Input.SaveAndMessageClick Action)
        {
            Action.Cancel();

            this.ErrorMessage = string.Empty;
            this.SuccessMessage = string.Empty;
            System.Threading.Thread.CurrentThread.Join(timeout);

            if (DateTime.Now.Ticks%2 == 0)
            {
                this.SuccessMessage = "The changes are successfully saved";
            }
            else
            {
                this.ErrorMessage = "Failed to save changes";
            }
        }

        protected void Handle(Input.SaveAndClientMessageClick Action)
        {
            Action.Cancel();
            System.Threading.Thread.CurrentThread.Join(timeout);
        }

        [CallbackPage_json.Items]
        partial class CallbackPageItem
        {
            protected int timeout = 1000;

            protected void Handle(Input.SaveClick Action)
            {
                Action.Cancel();
                System.Threading.Thread.CurrentThread.Join(timeout);
            }

            protected void Handle(Input.SaveAndSpinClick Action)
            {
                Action.Cancel();
                System.Threading.Thread.CurrentThread.Join(timeout);
            }

            protected void Handle(Input.SaveAndMessageClick Action)
            {
                Action.Cancel();

                this.ErrorMessage = string.Empty;
                this.SuccessMessage = string.Empty;
                System.Threading.Thread.CurrentThread.Join(timeout);

                if (DateTime.Now.Ticks%2 == 0)
                {
                    this.SuccessMessage = "The changes are successfully saved";
                }
                else
                {
                    this.ErrorMessage = "Failed to save changes";
                }
            }

            protected void Handle(Input.SaveAndClientMessageClick Action)
            {
                Action.Cancel();
                System.Threading.Thread.CurrentThread.Join(timeout);
            }
        }
    }
}