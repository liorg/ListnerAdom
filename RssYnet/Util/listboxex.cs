using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class ImprovedListBox : ListBox
{
    private Color highlight = SystemColors.Highlight;
    private IDictionary<int, Color> colorList;

    public ImprovedListBox()
    {
        DrawMode = DrawMode.OwnerDrawFixed;

        this.colorList = new Dictionary<int, Color>();
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

        Color textColor = Color.Empty;
        if (colorList.Count > 0)
        {
            if ((this.SelectionMode != SelectionMode.None) && ((e.State & DrawItemState.Selected) != DrawItemState.Selected))
            {
                textColor = GetItemColor(e.Index);

                if (textColor.IsEmpty)
                {
                    textColor = base.ForeColor;
                }
            }
            else
            {
                textColor = GetItemColor(e.Index);
            }
        }

        string text = this.Items[e.Index].ToString();

        TextRenderer.DrawText(e.Graphics, text, this.Font, rect, textColor, TextFormatFlags.GlyphOverhangPadding);
    }

    public void SetItemColor(int index, Color color)
    {
        colorList.Add(index, color);
    }

    public Color GetItemColor(int index)
    {
        if (colorList.ContainsKey(index))
        {
            return colorList[index];
        }
        else
        {
            return base.ForeColor;
        }
    }
}