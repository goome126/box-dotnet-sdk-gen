using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Box;
using Box.Schemas;
using Box.Managers;

namespace Box.Tests.Integration {
    [TestClass]
    public class FolderWatermarksManagerTests {
        public BoxClient client { get; }

        public FolderWatermarksManagerTests() {
            client = new CommonsManager().GetDefaultClient();
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestCreateGetDeleteFolderWatermark() {
            string folderName = Utils.GetUUID();
            FolderFull folder = await client.Folders.CreateFolderAsync(new CreateFolderRequestBodyArg(name: folderName, parent: new CreateFolderRequestBodyArgParentField(id: "0"))).ConfigureAwait(false);
            Watermark createdWatermark = await client.FolderWatermarks.UpdateFolderWatermarkAsync(folder.Id, new UpdateFolderWatermarkRequestBodyArg(watermark: new UpdateFolderWatermarkRequestBodyArgWatermarkField(imprint: UpdateFolderWatermarkRequestBodyArgWatermarkFieldImprintField.Default))).ConfigureAwait(false);
            Watermark watermark = await client.FolderWatermarks.GetFolderWatermarkAsync(folder.Id).ConfigureAwait(false);
            await client.FolderWatermarks.DeleteFolderWatermarkAsync(folder.Id).ConfigureAwait(false);
            await Assert.That.IsExceptionAsync(async() => await client.FolderWatermarks.GetFolderWatermarkAsync(folder.Id).ConfigureAwait(false));
            await client.Folders.DeleteFolderByIdAsync(folder.Id).ConfigureAwait(false);
        }

    }
}