﻿public class ButtonWidget : AbstractMenuWidget
{
	TextWidget _text;
	ButtonState _state;
	string _textureNameIdle;
	string _textureNameHover;
	string _textureNamePressed;

	public ButtonWidget()
	{
		_state = ButtonState.Normal;
		_textureNameIdle = "button.png";
		_textureNameHover = "button_sel.png";
		_textureNamePressed = "button_sel.png";
		x = 0;
		y = 0;
		sizex = 0;
		sizey = 0;
		clickable = true;
	}
	//public ButtonWidget(float dx, float dy, float dw, float dh, string text, FontCi font)
	//{
	//	_state = ButtonState.Normal;
	//	x = dx;
	//	y = dy;
	//	sizex = dw;
	//	sizey = dh;
	//	if ((text != null) && (text != ""))
	//	{
	//		_text = new TextWidget(x + sizex / 2, y + sizey / 2, text, font, TextAlign.Center, TextBaseline.Middle);
	//	}
	//}

	public override void OnMouseDown(GamePlatform p, MouseEventArgs args)
	{
		if (_state != ButtonState.Hover) { return; }
		SetState(ButtonState.Pressed);
	}

	public override void OnMouseUp(GamePlatform p, MouseEventArgs args)
	{
		if (_state != ButtonState.Pressed) { return; }
		SetState(ButtonState.Hover);
	}

	public override void OnMouseMove(GamePlatform p, MouseEventArgs args)
	{
		// Check if mouse is inside the button rectangle
		if (IsCursorInside(args))
		{
			if (_state == ButtonState.Normal)
			{
				SetState(ButtonState.Hover);
			}
		}
		else
		{
			SetState(ButtonState.Normal);
		}
	}

	public override void Draw(MainMenu m)
	{
		if (!visible) { return; }
		switch (_state)
		{
			// TODO: Use atlas textures
			case ButtonState.Normal:
				m.Draw2dQuad(m.GetTexture(_textureNameIdle), x, y, sizex, sizey);
				break;
			case ButtonState.Hover:
				m.Draw2dQuad(m.GetTexture(_textureNameHover), x, y, sizex, sizey);
				break;
			case ButtonState.Pressed:
				m.Draw2dQuad(m.GetTexture(_textureNamePressed), x, y, sizex, sizey);
				break;
		}

		if (_text != null)
		{
			_text.SetX(x + sizex / 2);
			_text.SetY(y + sizey / 2);
			_text.Draw(m);
		}
	}

	public void SetState(ButtonState state)
	{
		_state = state;
	}

	public void SetText(string text)
	{
		if (text == null || text == "") { return; }
		if (_text == null)
		{
			// Create new text widget if none exists
			FontCi font = new FontCi();
			font.size = 14;
			//_text = new TextWidget(x + sizex / 2, y + sizey / 2, text, font, TextAlign.Center, TextBaseline.Middle);
			_text = new TextWidget();
			_text.SetAlignment(TextAlign.Center);
			_text.SetBaseline(TextBaseline.Middle);
			_text.SetFont(font);
			_text.SetText(text);
		}
		else
		{
			// Change text of existing widget
			_text.SetText(text);
		}
	}

	public void SetTextureNames(string textureIdle, string textureHover, string texturePressed)
	{
		if (textureIdle != null && textureIdle != "")
		{
			_textureNameIdle = textureIdle;
		}
		if (textureHover != null && textureHover != "")
		{
			_textureNameHover = textureHover;
		}
		if (texturePressed != null && texturePressed != "")
		{
			_textureNamePressed = texturePressed;
		}
	}
}

public enum ButtonState
{
	Normal,
	Hover,
	Pressed
}
