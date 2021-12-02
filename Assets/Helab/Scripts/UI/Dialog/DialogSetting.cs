using System;

namespace Helab.UI.Dialog
{
    public struct DialogSetting
    {
        public string Title;

        public string Message;

        public string Cancel;

        public string Ok;
        
        public Action OnCancel;
        
        public Action OnOk;
    }
}
