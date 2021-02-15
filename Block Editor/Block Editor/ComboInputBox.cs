using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Block_Editor
{
	public partial class ComboInputBox : Form
	{
		public ComboInputBox()
		{
			InitializeComponent();
		}

		public ComboInputBox(string title, string message)
		{
			if (title == null) throw new ArgumentNullException(nameof(title));
			if (message == null) throw new ArgumentNullException(nameof(message));

			InitializeComponent();

			this.Text = title;
			this.lblText.Text = message;
		}

		public string Value = "air";
		public new void Show()
		{
			this.ShowDialog();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Value = comboBox1.SelectedIndex < 0 ? "air" : Form1.Blocks[comboBox1.SelectedIndex].ID;
		}
	}
}
