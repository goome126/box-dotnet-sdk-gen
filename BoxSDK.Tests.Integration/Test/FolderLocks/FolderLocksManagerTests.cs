using Microsoft.VisualStudio.TestTools.UnitTesting;
using NullableExtensions;
using System;
using Box;
using Box.Schemas;
using Box.Managers;

namespace Box.Tests.Integration {
    [TestClass]
    public class FolderLocksManagerTests {
        public BoxClient client { get; }

        public FolderLocksManagerTests() {
            client = new CommonsManager().GetDefaultClient();
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestFolderLocks() {
            FolderFull folder = await new CommonsManager().CreateNewFolderAsync().ConfigureAwait(false);
            FolderLocks folderLocks = await client.FolderLocks.GetFolderLocksAsync(queryParams: new GetFolderLocksQueryParams(folderId: folder.Id)).ConfigureAwait(false);
            Assert.IsTrue(NullableUtils.Unwrap(folderLocks.Entries).Count == 0);
            FolderLock folderLock = await client.FolderLocks.CreateFolderLockAsync(requestBody: new CreateFolderLockRequestBody(folder: new CreateFolderLockRequestBodyFolderField(id: folder.Id, type: "folder")) { LockedOperations = new CreateFolderLockRequestBodyLockedOperationsField(move: true, delete: true) }).ConfigureAwait(false);
            Assert.IsTrue(NullableUtils.Unwrap(folderLock.Folder).Id == folder.Id);
            Assert.IsTrue(NullableUtils.Unwrap(folderLock.LockedOperations).Move == true);
            Assert.IsTrue(NullableUtils.Unwrap(folderLock.LockedOperations).Delete == true);
            await client.FolderLocks.DeleteFolderLockByIdAsync(folderLockId: NullableUtils.Unwrap(folderLock.Id)).ConfigureAwait(false);
            await Assert.That.IsExceptionAsync(async() => await client.FolderLocks.DeleteFolderLockByIdAsync(folderLockId: NullableUtils.Unwrap(folderLock.Id)).ConfigureAwait(false));
            FolderLocks newFolderLocks = await client.FolderLocks.GetFolderLocksAsync(queryParams: new GetFolderLocksQueryParams(folderId: folder.Id)).ConfigureAwait(false);
            Assert.IsTrue(NullableUtils.Unwrap(newFolderLocks.Entries).Count == 0);
            await client.Folders.DeleteFolderByIdAsync(folderId: folder.Id).ConfigureAwait(false);
        }

    }
}