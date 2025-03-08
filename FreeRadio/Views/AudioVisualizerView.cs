using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using System;

namespace FreeRadio.Views
{
    class AudioVisualizerView : SKCanvasView
    {
        // An array holding the current audio levels (normalized 0 to 1)
        public float[] AudioLevels { get; private set; } = new float[64];

        public AudioVisualizerView()
        {
            // Hook up the paint event
            this.PaintSurface += OnPaintSurface;
        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            // Clear canvas with transparent background
            canvas.Clear(SKColors.Transparent);

            int barCount = AudioLevels.Length;
            float width = e.Info.Width;
            float height = e.Info.Height;
            float barWidth = width / barCount;
            // Calculate the center Y position for a double-sided visualizer
            float centerY = height / 2;

            using (var paint = new SKPaint { Color = SKColors.White, IsAntialias = true })
            {
                // Draw each bar based on the audio level value
                for (int i = 0; i < barCount; i++)
                {
                    float level = AudioLevels[i];
                    // Scale level to half of the canvas height
                    float halfBarHeight = level * centerY;
                    // Define a small gap between bars
                    float gap = 2;
                    float left = i * barWidth;
                    float right = (i + 1) * barWidth - gap;

                    // Create the top bar starting from the center going upward
                    var topRect = new SKRect(left, centerY - halfBarHeight, right, centerY);
                    // Create the bottom bar starting from the center going downward
                    var bottomRect = new SKRect(left, centerY, right, centerY + halfBarHeight);

                    // Set a corner radius to smooth the edges (adjust factor as needed)
                    float cornerRadius = (barWidth * 0.3f);

                    // Draw rounded rectangles for smooth edges
                    canvas.DrawRoundRect(topRect, cornerRadius, cornerRadius, paint);
                    canvas.DrawRoundRect(bottomRect, cornerRadius, cornerRadius, paint);
                }
            }
        }

        // Call this method to update the visualizer with new audio data.
        public void UpdateAudioLevels(float[] levels)
        {
            if (levels == null || levels.Length == 0)
                return;

            // Resize array if necessary
            if (levels.Length != AudioLevels.Length)
                AudioLevels = new float[levels.Length];

            Array.Copy(levels, AudioLevels, levels.Length);
            InvalidateSurface(); // Redraw the canvas
        }
    }
}
