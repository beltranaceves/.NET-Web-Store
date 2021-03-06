
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
    
public partial class Films : Product
{

    public string director { get; set; }

    public int filmYear { get; set; }

    public int duration { get; set; }

    public string genere { get; set; }


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


			hash = hash * multiplier + (director == null ? 0 : director.GetHashCode());

			hash = hash * multiplier + filmYear.GetHashCode();

			hash = hash * multiplier + duration.GetHashCode();

			hash = hash * multiplier + (genere == null ? 0 : genere.GetHashCode());


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
	    
        Films target = obj as Films;

		return true
           &&  (this.director == target.director )       
           &&  (this.filmYear == target.filmYear )       
           &&  (this.duration == target.duration )       
           &&  (this.genere == target.genere )       
           ;

    }



	public static bool operator ==(Films  objA, Films  objB)
    {
        // Check if the objets are the same Films entity
        if(Object.ReferenceEquals(objA, objB))
            return true;
  
        return objA.Equals(objB);
}



	public static bool operator !=(Films  objA, Films  objB)
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
	    StringBuilder strFilms = new StringBuilder();

		strFilms.Append("[ ");
       strFilms.Append(" director = " + director + " | " );       
       strFilms.Append(" filmYear = " + filmYear + " | " );       
       strFilms.Append(" duration = " + duration + " | " );       
       strFilms.Append(" genere = " + genere + " | " );       

        strFilms.Append("] ");    

		return strFilms.ToString();
    }



}

}
