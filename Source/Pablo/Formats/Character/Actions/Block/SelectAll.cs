using System;
using Eto.Drawing;
using Eto.Forms;
using Pablo.Formats.Character.Tools;

namespace Pablo.Formats.Character.Actions.Block
{
	public class SelectAll : ButtonAction
	{
		Selection tool;
		public const string ActionID = "character_SelectAll";
		
		public SelectAll(Selection tool)
		{
			this.tool = tool;
			ID = ActionID;
			Text = "Select All|Select All|Selects everything";
			Accelerator = Command.CommonModifier | Key.A;
		}
		
		protected override void OnActivated (EventArgs e)
		{
			
			var page = tool.Handler.CurrentPage;
			var canvas = page.Canvas;
			var endx = canvas.FindEndX (CanvasElement.Default);
			var endy = canvas.FindEndY (CanvasElement.Default);
			
			if (endx >= 0 && endy >= 0)
			{
				tool.SelectedRegion = new Rectangle(new Size(endx+1, endy+1));
				tool.DrawMode = DrawMode.Selecting;
				tool.Cancel (); // cancel right away, don't want mouse to move things around
			}
		}
		
	}
}

