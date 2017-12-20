﻿using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace Pong {
    static class Menu {
        static public int Show(string[] menu) {
            int selection = -1;
            if (menu.Length > 6)
                throw new System.Exception("Max menu size is 6!");
            BrainPad.Display.ClearScreen();
           

            for (int i = 0; i < menu.Length; i++)
                BrainPad.Display.DrawScaledText(20, 9 * i, menu[i], 1, 1);

            BrainPad.Display.DrawScaledText(0, 64 - 8, "R = Select ALL = Exit", 1, 1);
            BrainPad.Display.ShowOnScreen();
            while (true) {
                if (BrainPad.Buttons.IsDownPressed() || selection == -1) {
                    BrainPad.Buzzer.StartBuzzing(400);
                    BrainPad.Wait.Milliseconds(10);
                    BrainPad.Buzzer.StopBuzzing();

                    BrainPad.Display.DrawScaledText(0, selection * 9, " ", 2, 1);
                    selection++;
                    if (selection >= menu.Length)
                        selection = 0;

                    BrainPad.Display.DrawScaledText(0, selection * 9, ">", 2, 1);

                    BrainPad.Display.ShowOnScreen();

                    while (BrainPad.Buttons.IsDownPressed())
                        BrainPad.Wait.Minimum();
                }
                else if (BrainPad.Buttons.IsUpPressed() || selection == -1) {
                    BrainPad.Buzzer.StartBuzzing(400);
                    BrainPad.Wait.Milliseconds(10);
                    BrainPad.Buzzer.StopBuzzing();

                    BrainPad.Display.DrawScaledText(0, selection * 9, " ", 2, 1);

                    selection--;

                    if (selection < 0)
                        selection = menu.Length - 1;

                    BrainPad.Display.DrawScaledText(0, selection * 9, ">", 2, 1);
                    BrainPad.Display.ShowOnScreen();


                    while (BrainPad.Buttons.IsUpPressed())
                        BrainPad.Wait.Minimum();
                }

                if (BrainPad.Buttons.IsRightPressed())
                    return selection + 1;
                BrainPad.Wait.Minimum();


                int width = BrainPad.Display.Width;
            }

        }
    }
}