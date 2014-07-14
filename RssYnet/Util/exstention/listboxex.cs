using rssYnet.Util;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class ImprovedListBox : ListBox
{
    private Color highlight = SystemColors.Highlight;

    public ImprovedListBox()
    {
        DrawMode = DrawMode.OwnerDrawFixed;

    }

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        if (this.Font.Height < 0)
            this.Font = Control.DefaultFont;

        if (e.Index < 0)
            return;

        if (this.Items.Count == 0)
        {
            return;
        }

        Rectangle rect = base.GetItemRectangle(e.Index);

        Color highlight;
        if ((this.SelectionMode != SelectionMode.None) && ((e.State & DrawItemState.Selected) == DrawItemState.Selected))
            highlight = this.highlight;
        else
            highlight = this.BackColor;

        using (Brush brush = new SolidBrush(highlight))
        {
            e.Graphics.FillRectangle(brush, rect);
        }


        string text = this.Items[e.Index].ToString();
        MessageItem mitem = this.Items[e.Index] as MessageItem;
        Color foreColor = Color.Purple;
        if (mitem != null)
        {

            if (mitem.IsSearch)
            {
                foreColor = Color.Red;
            }

        }
        TextRenderer.DrawText(e.Graphics, text, this.Font, rect, foreColor, TextFormatFlags.GlyphOverhangPadding);
    }


}