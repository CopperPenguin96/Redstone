using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using static Microsoft.VisualBasic.Interaction;

namespace Block_Editor
{
	public partial class Form1 : Form
	{
		public static List<Block> Blocks = new List<Block>();
		private bool _editing = false;
		private bool _addStart = false;

		private Block block;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (File.Exists("blocks.json"))
			{
				Blocks = JsonConvert.DeserializeObject<List<Block>>("blocks.json");
				UpdateListView();

				foreach (var b in Blocks.Where(b => b.IsBaseType))
				{
					cboBaseType.Items.Add(b.Name);                       
				}
			}
		}
		
		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (lboBlockList.SelectedIndex > -1)
			{
				FillInfo(lboBlockList.SelectedIndex);
				block = Blocks[lboBlockList.SelectedIndex];
				_editing = true;
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			int selected = lboBlockList.SelectedIndex;
			if (selected > -1)
			{
				lboBlockList.Items.RemoveAt(selected);
				Blocks.RemoveAt(selected);
				_editing = false;
				UpdateListView();
			}
		}

		private void FillInfo(int index)
		{
			block = Blocks[index];
			txtName.Text = block.Name;
			cboStackable.Checked = block.IsStackable.Is;
			if (block.IsStackable == true)
			{
				numStackableCount.Value = block.IsStackable.Count;
			}

			numDefault.Value = block.BreakingTimes[0].Value;
			foreach (BreakingTime bt in block.BreakingTimes)
			{
				switch (bt.ToolType)
				{
					case ToolType.Default:
						numDefault.Value = bt.Value;
						break;
					case ToolType.Wooden:
						numWood.Value = bt.Value;
						break;
					case ToolType.Stone:
						numStone.Value = bt.Value;
						break;
					case ToolType.Iron:
						numIron.Value = bt.Value;
						break;
					case ToolType.Diamond:
						numDiamond.Value = bt.Value;
						break;
					case ToolType.Netherite:
						numNetherite.Value = bt.Value;
						break;
					case ToolType.Golden:
						numGolden.Value = bt.Value;
						break;
				}
			}

			switch (block.ToolRequired)
			{
				case ToolForm.Hand:
					radHand.Select();
					break;
				case ToolForm.Axe:
					radHand.Select();
					break;
				case ToolForm.Pickaxe:
					radHand.Select();
					break;
				case ToolForm.Hoe:
					radHand.Select();
					break;
				case ToolForm.Shovel:
					radHand.Select();
					break;
			}

			numBlast.Value = (decimal) block.BlastResistance;
			numHardness.Value = (decimal) block.Hardness;
			cboLum.Checked = block.Luminant;
			cboTransparent.Checked = block.Transparent;
			cboFlammable.Checked = block.Flammable;
			cboLavaFlam.Checked = block.LavaFlammable;
			chkBaseType.Checked = block.IsBaseType;
			numericUpDown1.Maximum = block.CraftRecipe.Count - 1;

			FillCraft(0);

			txtID.Text = block.ID;
			txtTranslationKey.Text = block.TranslationKey;
		}


		private void timer1_Tick(object sender, EventArgs e)
		{
			gboBlockEditor.Enabled = _addStart;
			btnEdit.Enabled = lboBlockList.SelectedIndex != -1;
			btnDelete.Enabled = lboBlockList.SelectedIndex != -1;
		}

		private void cboStackable_CheckedChanged(object sender, EventArgs e)
		{
			numStackableCount.Enabled = cboStackable.Checked;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			txtName.ResetText();
			cboStackable.Checked = false;
			numStackableCount.Value = 0;

			foreach (Control c in gboBreakingTimes.Controls)
			{
				if (c.GetType() == typeof(NumericUpDown))
				{
					((NumericUpDown) c).Value = 0;
				}
			}

			radHand.Checked = true;
			numBlast.Value = 0;
			numHardness.Value = 0;
			cboLum.Checked = false;
			cboTransparent.Checked = false;
			cboFlammable.Checked = false;
			cboLavaFlam.Checked = false;
			txtID.ResetText();
			txtTranslationKey.ResetText();
			chkBaseType.Checked = false;
			numericUpDown1.Maximum = 0;

			for (int x = 1; x <= 9; x++)
			{
				string name = "btnSpot" + x;
				string textValue = "";
				if (x == 3 || x == 6 || x == 7 || x == 8 || x == 9)
				{
					textValue = "{Empty}";
				}
				else
				{
					textValue = "Spot " + x;
				}

				foreach (Control c in gboCraftRecipe.Controls)
				{
					if (name == c.Name)
					{
						c.Text = textValue;
					}
				}
			}
		}

		public enum ToolForm { Hand, Axe, Pickaxe, Hoe, Shovel }

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (!_editing && Blocks.Where(b => b.ID == txtID.Text).ToList().Count > 0)
			{
				MessageBox.Show(
					"Block with same ID already exists. If editing, select block from list and hit \"Edit\".");
				return;
			}
			
			if (ErrorCheck(out string val))
			{
				MessageBox.Show("Please fix the following errors:\n\n" + val);
				return;
			}

			Block block = new Block
			{
				ID = txtID.Text,
				TranslationKey = txtTranslationKey.Text,
				Name = txtName.Text,
				IsStackable = new Stackable(cboStackable.Checked,
					(short) (cboStackable.Checked ? numStackableCount.Value : -1)),
				BreakingTimes = new List<BreakingTime>
				{
					new BreakingTime(ToolType.Default, numDefault.Value),
					new BreakingTime(ToolType.Wooden, numWood.Value),
					new BreakingTime(ToolType.Stone, numStone.Value),
					new BreakingTime(ToolType.Iron, numIron.Value),
					new BreakingTime(ToolType.Diamond, numDiamond.Value),
					new BreakingTime(ToolType.Netherite, numNetherite.Value),
					new BreakingTime(ToolType.Golden, numGolden.Value)
				},
				BlastResistance = (int) numBlast.Value,
				Hardness = (int) numHardness.Value,
				Luminant = cboLum.Checked,
				Transparent = cboTransparent.Checked,
				Flammable = cboFlammable.Checked,
				LavaFlammable = cboLavaFlam.Checked,
				CraftRecipe = allRecipes(),
				IsBaseType = chkBaseType.Checked
			};

			if (radHand.Checked) block.ToolRequired = ToolForm.Hand;
			if (radAxe.Checked) block.ToolRequired = ToolForm.Axe;
			if (radPickaxe.Checked) block.ToolRequired = ToolForm.Pickaxe;
			if (radHoe.Checked) block.ToolRequired = ToolForm.Hoe; // hehe
			if (radShovel.Checked) block.ToolRequired = ToolForm.Shovel;
			if (_editing)
			{
				for (var index = 0; index < Blocks.Count; index++)
				{
					Block b = Blocks[index];
					if (b.ID == txtID.Text)
					{
						Blocks.RemoveAt(index);
						lboBlockList.Items.RemoveAt(index);
						UpdateListView();
					}
				}
			}

			Blocks.Add(block);
			string file = "blocks.json";
			string json = JsonConvert.SerializeObject(Blocks, Formatting.Indented);
			var fileWriter = File.CreateText(file);
			fileWriter.Write(json);
			fileWriter.Flush();
			fileWriter.Close();
			UpdateListView();
		}

		private List<string[,]> allRecipes()
		{
			List<string[,]> all = new List<string[,]>();
			for (int x = 0; x < RecipeControlList.Count; x++)
			{
				all.Add(recipe(x));
			}

			return all;
		}

		private List<List<Button>> RecipeControlList = new List<List<Button>>();
		private string[,] recipe(int recipe)
		{
			List<Button> current = RecipeControlList[recipe];
			string[,] spots = null;
			if (current[2].Text == "{Empty}" || current[5].Text == "{Empty}" ||
			    current[6].Text == "{Empty}" || current[7].Text == "{Empty}" ||
			    current[8].Text == "{Empty}")
			{
				spots = new string[2, 2];
				spots[0, 0] = current[3].Text;
				spots[1, 0] = current[4].Text;
				spots[0, 1] = current[0].Text;
				spots[1, 1] = current[1].Text;
			}
			else
			{
				spots[0, 0] = current[6].Text;
				spots[0, 1] = current[7].Text;
				spots[0, 2] = current[8].Text;
				spots[1, 0] = current[3].Text;
				spots[1, 1] = current[4].Text;
				spots[1, 2] = current[5].Text;
				spots[2, 0] = current[0].Text;
				spots[2, 1] = current[1].Text;
				spots[2, 2] = current[2].Text;
			}

			return spots;
		}

		private string[,] recipeCurrent()
		{
			return recipe((int) numericUpDown1.Value);
		}
		private bool ErrorCheck(out string message)
		{
			message = "";
			if (txtName.Text == string.Empty) message += "Name cannot be empty\n";
			if (txtID.Text == string.Empty) message += "ID cannot be empty\n";
			if (cboStackable.Checked && numStackableCount.Value == 0) message += "Stackable must be more than 0\n";

			int extrasEmpty = 0;

			if (btnSpot3.Text == "{Empty}") extrasEmpty++;
			if (btnSpot6.Text == "{Empty}") extrasEmpty++;
			if (btnSpot7.Text == "{Empty}") extrasEmpty++;
			if (btnSpot8.Text == "{Empty}") extrasEmpty++;
			if (btnSpot9.Text == "{Empty}") extrasEmpty++;

			if (extrasEmpty >= 1 && extrasEmpty < 5)
			{
				message += "Craft Recipes Outliers must all be empty or be set to Air";
			}
			return message == "";
		}

		private void btnAddNew_Click(object sender, EventArgs e)
		{
			_editing = false;
			btnReset_Click(sender, e);
			_addStart = true;
		}

		private void UpdateListView()
		{
			foreach (Block b in Blocks)
			{
				lboBlockList.Items.Add(b.Name);
			}
		}

		private void btnSpot1_Click(object sender, EventArgs e)
		{
			int spot = int.Parse(((Button) sender).Name.Substring(7));
			ComboInputBox cBox = new ComboInputBox("Spot #" + spot, "Select a item to insert in this spot.");
			cBox.ShowDialog();

			if (cBox.Value == "air")
			{
				string chosen = "";
				string word = (spot == 3 || spot >= 6) ? "{Empty}" : "air";
				string val = InputBox($"You chose to not select anything or your item wasn't listed. Skip by typing {word}. Otherwise, type in your item id.", 
					"Item Type", word);
				chosen = val == word ? word : val;

				foreach (Control c in gboCraftRecipe.Controls)
				{
					Button b = (Button)c;
					if (b.Name == "btnSpot" + spot)
					{
						b.Text = chosen;
					}
				}
			}
		}

		private void cboBaseType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboBaseType.SelectedIndex > -1)
			{
				for (var index = 0; index < Blocks.Count; index++)
				{
					Block b = Blocks[index];
					if (b.Name == cboBaseType.SelectedText && b.IsBaseType)
					{
						FillInfo(index);
					}
				}
			}
		}

		private void gboCraftRecipe_Enter(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			FillCraft((int) numericUpDown1.Value);
		}

		private void FillCraft(int recipe)
		{
			string empty = "{Empty}";
			string[,] rec = allRecipes()[recipe];
			if (rec.Length == 4)
			{
				btnSpot3.Text = empty;
				btnSpot6.Text = empty;
				btnSpot7.Text = empty;
				btnSpot8.Text = empty;
				btnSpot9.Text = empty;
				btnSpot4.Text = rec[0, 0];
				btnSpot5.Text = rec[0, 1];
				btnSpot1.Text = rec[1, 0];
				btnSpot2.Text = rec[1, 1];
			}
			else
			{
				btnSpot7.Text = rec[0, 0];
				btnSpot8.Text = rec[0, 1];
				btnSpot9.Text = rec[0, 2];
				btnSpot4.Text = rec[1, 0];
				btnSpot5.Text = rec[1, 1];
				btnSpot6.Text = rec[1, 2];
				btnSpot1.Text = rec[2, 0];
				btnSpot2.Text = rec[2, 1];
				btnSpot3.Text = rec[2, 2];
			}
		}

		private void btnAddRecipe_Click(object sender, EventArgs e)
		{
			numericUpDown1.Maximum += 1;
			numericUpDown1.Value += 1;
			foreach (Control control in gboCraftRecipe.Controls)
			{
				if (control is Button b)
				{
					b.ResetText();
				}
			}

			
		}

		private void lboBlockList_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void btnDeleteRecipe_Click(object sender, EventArgs e)
		{
			block.CraftRecipe.RemoveAt((int) numericUpDown1.Value);
			RecipeControlList.RemoveAt((int) numericUpDown1.Value);
			numericUpDown1.Maximum -= 1;
			numericUpDown1.Value -= 1;

			FillCraft(0);
			numericUpDown1.Value = 0;
		}
	}
}
