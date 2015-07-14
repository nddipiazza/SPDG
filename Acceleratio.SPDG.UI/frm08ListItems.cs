﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Acceleratio.SPDG.UI
{
    public partial class frm08ListItems : frmWizardMaster
    {
        public frm08ListItems()
        {
            InitializeComponent();

            base.lblTitle.Text = "List Items";

            btnNext.Click += btnNext_Click;
            btnBack.Click += btnBack_Click;
            ucSteps1.showStep(8);
            this.Text = Common.APP_TITLE;

            loadData();
        }

        void btnBack_Click(object sender, EventArgs e)
        {
            preventCloseMessage = true;
            RootForm.MovePrevious(this);
            this.Close();
        }

        void btnNext_Click(object sender, EventArgs e)
        {
            preventCloseMessage = true;
            RootForm.MoveNext(this);
            this.Close();
        }

        public override void loadData()
        {
            chkPrefil.Checked = Common.WorkingDefinition.PrefilListAndLibrariesWithItems;
            trackMaxNumberOfItems.Value = Common.WorkingDefinition.MaxNumberofItemsToGenerate;
            chkDOCX.Checked = Common.WorkingDefinition.IncludeDocTypeDOCX;
            chkXLSX.Checked = Common.WorkingDefinition.IncludeDocTypeXLSX;
            chkPDF.Checked = Common.WorkingDefinition.IncludeDocTypePDF;
            chkImages.Checked = Common.WorkingDefinition.IncludeDocTypeImages;
            trackMinDocSize.Value = Common.WorkingDefinition.MinDocumentSizeKB;
            trackMaxDocSize.Value = Common.WorkingDefinition.MaxDocumentSizeMB;
        }

        public override bool saveData()
        {
            Common.WorkingDefinition.PrefilListAndLibrariesWithItems = chkPrefil.Checked;
            Common.WorkingDefinition.MaxNumberofItemsToGenerate = trackMaxNumberOfItems.Value;
            Common.WorkingDefinition.IncludeDocTypeDOCX = chkDOCX.Checked;
            Common.WorkingDefinition.IncludeDocTypeXLSX= chkXLSX.Checked;
            Common.WorkingDefinition.IncludeDocTypePDF= chkPDF.Checked;
            Common.WorkingDefinition.IncludeDocTypeImages = chkImages.Checked;
            Common.WorkingDefinition.MinDocumentSizeKB = trackMinDocSize.Value;
            Common.WorkingDefinition.MaxDocumentSizeMB  = trackMaxDocSize.Value;
            return true;
        }
    }
}
