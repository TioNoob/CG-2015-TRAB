using CosmicSimulator.Extensions;
using CosmicSimulatorController;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

namespace CosmicSimulator
{
    public class Initializer
    {
        [STAThread]
        private static void Main(string[] args)
        {
            using (GameWindow game = new GameWindow())
            {
                game.Load += Init(game);

                game.Resize += OnResize(game);

                game.UpdateFrame += GameLogic(game);

                game.RenderFrame += UpdateImage(game);

                game.Run(1, 1);
            }
        }

        public static EventHandler<EventArgs> Init(GameWindow game)
        {
            return (sender, e) =>
                {
                    CosmicController.Instance.LoadSolarSystem();

                    game.VSync = VSyncMode.On;
                    game.Title = "Cosmic Simulator";
                    //game.WindowState = WindowState.Fullscreen;
                };
        }

        public static EventHandler<EventArgs> OnResize(GameWindow game)
        {
            return (sender, e) =>
            {
                GL.Viewport(0, 0, game.Width, game.Height);
            };
        }

        public static EventHandler<FrameEventArgs> GameLogic(GameWindow game)
        {
            return (sender, e) =>
            {
                if (OpenTK.Input.Keyboard.GetState().IsKeyDown(Key.Escape))
                    game.Exit();
            };
        }

        public static EventHandler<FrameEventArgs> UpdateImage(GameWindow game)
        {
            return (sender, e) =>
            {
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);

                GL.Color3(Color.White);

                CosmicController.Instance.UpdateOrbsPosition();
                CosmicController.Instance.Orbs.ForEach(
                        orb => game.DrawCircle(orb.Radius, orb.ActualPosition)
                    );

                game.SwapBuffers();
            };
        }
    }
}