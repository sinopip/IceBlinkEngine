using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IceBlinkCore
{
    public class ShadowTextObject
    {
        #region Fields
        private string _text = "";
        private int _x = 0;
        private int _y = 0;
        private int _z = 0;
        private int aShadow = 0;
        private int aText = 0;
        private int _timer = 0;
        private bool _fadein = false;
        private bool _fadeout = false;
        private FontFamily _font;
        private float _fontPointSize = 18;
        private int _timeLength = 50;
        private int _floatSpeed = 5;
        private Color _textColor;
        private Color _shadowColor;
        #endregion

        #region Properties
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int Z
        {
            get { return _z; }
            set { _z = value; }
        }
        public int AlphaShadow
        {
            get { return aShadow; }
            set { aShadow = value; }
        }
        public int AlphaText
        {
            get { return aText; }
            set { aText = value; }
        }
        public int Timer
        {
            get { return _timer; }
            set { _timer = value; }
        }
        public bool FadeIn
        {
            get { return _fadein; }
            set { _fadein = value; }
        }
        public bool FadeOut
        {
            get { return _fadeout; }
            set { _fadeout = value; }
        }
        public FontFamily Font
        {
            get { return _font; }
            set { _font = value; }
        }
        public float FontPointSize
        {
            get { return _fontPointSize; }
            set { _fontPointSize = value; }
        }
        public int TimeLength
        {
            get { return _timeLength; }
            set { _timeLength = value; }
        }
        public int FloatSpeed
        {
            get { return _floatSpeed; }
            set { _floatSpeed = value; }
        }
        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; }
        }
        public Color ShadowColor
        {
            get { return _shadowColor; }
            set { _shadowColor = value; }
        }
        #endregion

        public ShadowTextObject(string text, int x, int y, int timeLength, Color textColor, Color shadowColor)
        {
            _text = text;
            _x = x;
            _y = y;
            _timeLength = timeLength;
            _textColor = textColor;
            _shadowColor = shadowColor;
        }
        public ShadowTextObject(string text, int x, int y, int timeLength, int floatSpeed, Color textColor, Color shadowColor)
        {
            _text = text;
            _x = x;
            _y = y;
            _timeLength = timeLength;
            _textColor = textColor;
            _shadowColor = shadowColor;
            _floatSpeed = floatSpeed;
        }
    }
}
