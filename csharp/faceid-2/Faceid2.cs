public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    public override bool Equals(object obj)
    {
        if (obj is not FacialFeatures f) return false;
        return this.EyeColor == f.EyeColor && this.PhiltrumWidth == f.PhiltrumWidth;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    // TODO: implement equality and GetHashCode() methods
    public override bool Equals(object obj)
    {
        if (obj is not Identity f) return false;
        return this.FacialFeatures.Equals(f.FacialFeatures) && this.Email == f.Email;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    HashSet<Identity> registered = new HashSet<Identity>();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity)
    {
        Identity admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
        return admin.Equals(identity);
    }
    public bool Register(Identity identity)
    {
        if (registered.Contains(identity)) return false;
        else
        {
            registered.Add(identity);
            return true;
        }
    }
    public bool IsRegistered(Identity identity) => registered.Contains(identity);
    public static bool AreSameObject(Identity identityA, Identity identityB) => object.ReferenceEquals(identityA, identityB);
}
