
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Es.Udc.DotNet.PracticaMad.Model
{

using System;
    using System.Text;
    using System.Collections.Generic;
    
public partial class Books : Product
{

    public string author { get; set; }

    public int pages { get; set; }

    public long ISBN { get; set; }

    public string editorial { get; set; }


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


			hash = hash * multiplier + (author == null ? 0 : author.GetHashCode());

			hash = hash * multiplier + pages.GetHashCode();

			hash = hash * multiplier + ISBN.GetHashCode();

			hash = hash * multiplier + (editorial == null ? 0 : editorial.GetHashCode());


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
	    
        Books target = obj as Books;

		return true
           &&  (this.author == target.author )       
           &&  (this.pages == target.pages )       
           &&  (this.ISBN == target.ISBN )       
           &&  (this.editorial == target.editorial )       
           ;

    }



	public static bool operator ==(Books  objA, Books  objB)
    {
        // Check if the objets are the same Books entity
        if(Object.ReferenceEquals(objA, objB))
            return true;
  
        return objA.Equals(objB);
}



	public static bool operator !=(Books  objA, Books  objB)
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
	    StringBuilder strBooks = new StringBuilder();

		strBooks.Append("[ ");
       strBooks.Append(" author = " + author + " | " );       
       strBooks.Append(" pages = " + pages + " | " );       
       strBooks.Append(" ISBN = " + ISBN + " | " );       
       strBooks.Append(" editorial = " + editorial + " | " );       

        strBooks.Append("] ");    

		return strBooks.ToString();
    }



}

}
