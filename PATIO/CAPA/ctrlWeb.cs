﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PATIO.CAPA
{
    public partial class ctrlWeb : UserControl
    {
        public string url;

        public ctrlWeb()
        {
            InitializeComponent();
            Initialise();
        }

        public void Initialise()
        {
            wb.Navigate(url);
        }
    }
}
