using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderPrinter.Services {
    class SoundPlayer {
        public static void Play(Sound sound) {
            Stream stream = null;
            switch (sound) {
                case Sound.NewOrder:
                    stream = Properties.Resources.new_order;
                    break;
                case Sound.CancelOrder:
                    stream = Properties.Resources.cancel_order;
                    break;
            }
            System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer(stream);
            soundPlayer.Play();
        }
    }

    enum Sound {
        NewOrder,
        CancelOrder
    }
}
