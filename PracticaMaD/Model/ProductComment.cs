//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Es.Udc.DotNet.PracticaMad.Model
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    
    public partial class ProductComment
    {
        public ProductComment()
        {
            this.Tag = new HashSet<Tag>();
        }
    
        public long commentId { get; set; }
        public long productId { get; set; }
        public string commentText { get; set; }
        public System.DateTime commentDate { get; set; }
        public long clientId { get; set; }
    
        
        /// <summary>
        /// Relationship Name (Foreign Key in ER-Model): FK_Comment_ClientId
        /// </summary>
        public virtual Client Client { get; set; }
        
        /// <summary>
        /// Relationship Name (Foreign Key in ER-Model): FK_Comment_Product
        /// </summary>
        public virtual Product Product { get; set; }
        
        /// <summary>
        /// Relationship Name (Foreign Key in ER-Model): ProductCommentTag
        /// </summary>
        public virtual ICollection<Tag> Tag { get; set; }
    
    	/// <summary>
    	/// A hash code for this instance, suitable for use in hashing algorithms and data structures 
    	/// like a hash table. It uses the Josh Bloch implementation from "Effective Java"
        /// Primary key of entity is not included in the hash calculation to avoid errors
    	/// with Entity Framework creation of key values.
    	/// </summary>
    	/// <returns>
    	/// Returns a hash code for this instance.
    	/// </returns>
    	public override int GetHashCode()
    	{
    	    unchecked
    	    {
    			int multiplier = 31;
    			int hash = GetType().GetHashCode();
    
    			hash = hash * multiplier + productId.GetHashCode();
    			hash = hash * multiplier + (commentText == null ? 0 : commentText.GetHashCode());
    			hash = hash * multiplier + commentDate.GetHashCode();
    			hash = hash * multiplier + clientId.GetHashCode();
    
    			return hash;
    	    }
    
    	}
        
        /// <summary>
        /// Compare this object against another instance using a value approach (field-by-field) 
        /// </summary>
        /// <remarks>See http://www.loganfranken.com/blog/687/overriding-equals-in-c-part-1/ for detailed info </remarks>
    	public override bool Equals(object obj)
    	{
    
            if (ReferenceEquals(null, obj)) return false;        // Is Null?
            if (ReferenceEquals(this, obj)) return true;         // Is same object?
            if (obj.GetType() != this.GetType()) return false;   // Is same type?
    	    
            ProductComment target = obj as ProductComment;
    
    		return true
               &&  (this.commentId == target.commentId )       
               &&  (this.productId == target.productId )       
               &&  (this.commentText == target.commentText )       
               &&  (this.commentDate == target.commentDate )       
               &&  (this.clientId == target.clientId )       
               ;
    
        }
    
    
    	public static bool operator ==(ProductComment  objA, ProductComment  objB)
        {
            // Check if the objets are the same ProductComment entity
            if(Object.ReferenceEquals(objA, objB))
                return true;
      
            return objA.Equals(objB);
    }
    
    
    	public static bool operator !=(ProductComment  objA, ProductComment  objB)
        {
            return !(objA == objB);
        }
    
    
        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the 
        /// current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current 
        /// <see cref="T:System.Object"></see>.
        /// </returns>
    	public override String ToString()
    	{
    	    StringBuilder strProductComment = new StringBuilder();
    
    		strProductComment.Append("[ ");
           strProductComment.Append(" commentId = " + commentId + " | " );       
           strProductComment.Append(" productId = " + productId + " | " );       
           strProductComment.Append(" commentText = " + commentText + " | " );       
           strProductComment.Append(" commentDate = " + commentDate + " | " );       
           strProductComment.Append(" clientId = " + clientId + " | " );       
            strProductComment.Append("] ");    
    
    		return strProductComment.ToString();
        }
    
    
    }
}
