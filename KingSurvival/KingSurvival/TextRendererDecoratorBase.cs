﻿namespace KingSurvivalGame
{
    public abstract class TextRendererDecoratorBase : RendererBase // decorator design pattern decorator base
    {
        private readonly RendererBase rendererBase;

        public TextRendererDecoratorBase(RendererBase rendererBase)
        {
            // check data
            this.rendererBase = rendererBase;
        }

        public override void Render(char[,] objectToRender, int offsetX, int offsetY)
        {
            this.rendererBase.Render(objectToRender, offsetX, offsetY);
        }

        public override void ClearScreen()
        {
            this.rendererBase.ClearScreen();
        }

        public abstract void RenderText(string text, int initialLeft, int initialTop);
    }
}
