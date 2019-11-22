using System;

public class UserYoutube : Live.Core.Entity
{
    public Guid UserId {get; protected set;}

    public Guid? FolderId {get; protected set;}
    public string VideoId {get; protected set;}
    public string LocLeft {get; protected set;}
    public string LocTop {get; protected set;}
    public string Title {get; protected set;}
    //public User User {get; protected set;}
    public DateTime CreatedAt {get; protected set;}
    public DateTime? AddedToFolder {get; protected set;}
    

        public UserYoutube()
        {
        }

        public UserYoutube(string userId, string videoId, string title, string left, string top, string folderId) 
        {
            UserId = new Guid(userId);
            Title = title;

        if(string.IsNullOrEmpty(folderId))
        {
            FolderId = null;
        }
        else 
        {
            FolderId =  new Guid(folderId);
        }

            VideoId = videoId;
            LocLeft = left;
            LocTop = top;
            CreatedAt = DateTime.Now;
        }

          public UserYoutube( string videoId, string title, string left, string top) 
        {
            //UserId = new Guid(userId);
            Title = title;
            FolderId = null;
            VideoId = videoId;
            LocLeft = left;
            LocTop = top;
            CreatedAt = DateTime.Now;
        }

        public void SetFolder(Guid folderId)
        {
            if(this.FolderId == null)
            {
                this.FolderId = folderId;
                this.AddedToFolder = DateTime.Now;
            }
        }

        public void RemoveFromFolder()
        {
            if(this.FolderId != null)
            {
                this.FolderId = null;
                this.AddedToFolder = null;
            }
        }

        public void ChangeLocation(string left, string top)
        {
            this.LocLeft = left;
            this.LocTop = top;
        }

        
}