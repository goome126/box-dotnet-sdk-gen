using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using NullableExtensions;
using StringExtensions;
using Box;
using Box.Schemas;

namespace Box.Tests.Integration {
    [TestClass]
    public class ZipDownloadsManagerTests {
        public BoxClient client { get; }

        public ZipDownloadsManagerTests() {
            client = new CommonsManager().GetDefaultClient();
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestZipDownload() {
            FileFull file1 = await new CommonsManager().UploadNewFileAsync().ConfigureAwait(false);
            FileFull file2 = await new CommonsManager().UploadNewFileAsync().ConfigureAwait(false);
            FolderFull folder1 = await new CommonsManager().CreateNewFolderAsync().ConfigureAwait(false);
            System.IO.Stream zipStream = await client.ZipDownloads.DownloadZipAsync(requestBody: new ZipDownloadRequest(items: Array.AsReadOnly(new [] {new ZipDownloadRequestItemsField(id: file1.Id, type: ZipDownloadRequestItemsTypeField.File),new ZipDownloadRequestItemsField(id: file2.Id, type: ZipDownloadRequestItemsTypeField.File),new ZipDownloadRequestItemsField(id: folder1.Id, type: ZipDownloadRequestItemsTypeField.Folder)})) { DownloadFileName = "zip" }).ConfigureAwait(false);
            Assert.IsTrue(Utils.BufferEquals(buffer1: await Utils.ReadByteStreamAsync(byteStream: zipStream).ConfigureAwait(false), buffer2: Utils.GenerateByteBuffer(size: 10)) == false);
            await client.Files.DeleteFileByIdAsync(fileId: file1.Id).ConfigureAwait(false);
            await client.Files.DeleteFileByIdAsync(fileId: file2.Id).ConfigureAwait(false);
            await client.Folders.DeleteFolderByIdAsync(folderId: folder1.Id).ConfigureAwait(false);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestManualZipDownloadAndCheckStatus() {
            FileFull file1 = await new CommonsManager().UploadNewFileAsync().ConfigureAwait(false);
            FileFull file2 = await new CommonsManager().UploadNewFileAsync().ConfigureAwait(false);
            FolderFull folder1 = await new CommonsManager().CreateNewFolderAsync().ConfigureAwait(false);
            ZipDownload zipDownload = await client.ZipDownloads.CreateZipDownloadAsync(requestBody: new ZipDownloadRequest(items: Array.AsReadOnly(new [] {new ZipDownloadRequestItemsField(id: file1.Id, type: ZipDownloadRequestItemsTypeField.File),new ZipDownloadRequestItemsField(id: file2.Id, type: ZipDownloadRequestItemsTypeField.File),new ZipDownloadRequestItemsField(id: folder1.Id, type: ZipDownloadRequestItemsTypeField.Folder)})) { DownloadFileName = "zip" }).ConfigureAwait(false);
            Assert.IsTrue(zipDownload.DownloadUrl != "");
            Assert.IsTrue(zipDownload.StatusUrl != "");
            Assert.IsTrue(zipDownload.ExpiresAt != "");
            System.IO.Stream zipStream = await client.ZipDownloads.GetZipDownloadContentAsync(downloadUrl: NullableUtils.Unwrap(zipDownload.DownloadUrl)).ConfigureAwait(false);
            Assert.IsTrue(Utils.BufferEquals(buffer1: await Utils.ReadByteStreamAsync(byteStream: zipStream).ConfigureAwait(false), buffer2: Utils.GenerateByteBuffer(size: 10)) == false);
            ZipDownloadStatus zipDownloadStatus = await client.ZipDownloads.GetZipDownloadStatusAsync(statusUrl: NullableUtils.Unwrap(zipDownload.StatusUrl)).ConfigureAwait(false);
            Assert.IsTrue(zipDownloadStatus.TotalFileCount == 2);
            Assert.IsTrue(zipDownloadStatus.DownloadedFileCount == 2);
            Assert.IsTrue(zipDownloadStatus.SkippedFileCount == 0);
            Assert.IsTrue(zipDownloadStatus.SkippedFolderCount == 0);
            Assert.IsTrue(StringUtils.ToStringRepresentation(zipDownloadStatus.State) != "failed");
            await client.Files.DeleteFileByIdAsync(fileId: file1.Id).ConfigureAwait(false);
            await client.Files.DeleteFileByIdAsync(fileId: file2.Id).ConfigureAwait(false);
            await client.Folders.DeleteFolderByIdAsync(folderId: folder1.Id).ConfigureAwait(false);
        }

    }
}