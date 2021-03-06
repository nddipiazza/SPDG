﻿using System.Collections.Generic;
using Acceleratio.SPDG.Generator.SPModel;
using Microsoft.SharePoint;

namespace Acceleratio.SPDG.Generator.Server.SPModel
{
    class SPDGServerFolder : SPDGFolder
    {
        private SPFolder _folder;
        public SPDGServerFolder(SPFolder folder)
        {
            this._folder = folder;
        }

        public override string Name
        {
            get { return _folder.Name; }
        }

        public override string Url
        {
            get { return _folder.Url; }
        }

        public override IEnumerable<SPDGFolder> SubFolders
        {
            get
            {
                foreach (SPFolder subFolder in _folder.SubFolders)
                {
                    yield return new SPDGServerFolder(subFolder);
                }
            }
        }

        public override SPDGListItem Item
        {
            get
            {
                return new SPDGServerListItem(_folder.Item);
            }
        }

        public override SPDGFolder AddFolder(string name)
        {
           var spFolder = _folder.SubFolders.Add(name);
            return new SPDGServerFolder(spFolder);
        }

        public override SPDGFile AddFile(string url, byte[] content, bool overWrite)
        {
            var file=_folder.Files.Add(url, content, overWrite);
            return new SPDGServerFile(file);
        }

        public override void Update()
        {
            _folder.Update();
        }
    }
}
