using System.Text;

namespace Redstone.Utils
{
    public class MinecraftVersion
    {
        /// <summary>
        /// 1.17.1 - 756
        /// </summary>
        public static readonly MinecraftVersion Current = new(756, 1, 17, 1);
        
        public int Protocol { get; set; }
        

        public MinecraftVersion(int protocol, int major = 1, int minor = 0, int build = -1, int revision = -1)
        {
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
            Protocol = protocol;
        }

        /// <summary>
        /// <inheritdoc cref="Version.Major"></inheritdoc>
        /// </summary>
        public int Major { get; set; }

        /// <summary>
        /// <inheritdoc cref="Version.Minor"></inheritdoc>
        /// </summary>
        public int Minor { get; set; }

        /// <summary>
        /// <inheritdoc cref="Version.Build"></inheritdoc>
        /// </summary>
        public int Build { get; set; }

        /// <summary>
        /// <inheritdoc cref="Version.Revision"></inheritdoc>
        /// </summary>
        public int Revision { get; set; }
    

        /// <summary>
        /// Represents the version in its textual format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new($"{Major}.{Minor}");
            if (Build <= -1) return builder.ToString();
            builder.Append($".{Build}");
            if (Revision > -1) builder.Append($".{Revision}");

            return builder.ToString();
        }

        #region Operators 

        public static bool operator >(MinecraftVersion version1, MinecraftVersion version2)
        {
            if (version1.Major > version2.Major) return true;
            else if (version1.Major < version2.Major) return false;
            else
            {
                if (version1.Minor > version2.Minor) return true;
                else if (version1.Minor < version2.Minor) return false;
                else
                {
                    if (version1.Build > version2.Build) return true;
                    else if (version1.Build < version2.Build) return false;
                    else
                    {
                        if (version1.Revision > version2.Revision) return true;
                        else if (version1.Revision < version2.Revision) return false;
                        else return false;
                    }
                }
            }
        }

        public static bool operator <(MinecraftVersion version1, MinecraftVersion version2)
        {
            return !(version1 > version2);
        }

        public static bool operator >=(MinecraftVersion version1, MinecraftVersion version2)
        {
            if (version1 > version2) return true;
            else if (version1 < version2) return false;
            else return true;
        }

        public static bool operator <=(MinecraftVersion version1, MinecraftVersion version2)
        {
            if (version1 < version2) return true;
            else if (version1 > version2) return false;
            else return true;
        }

        public static bool operator ==(MinecraftVersion version1, MinecraftVersion version2)
        {
            return version1.Protocol == version2.Protocol;
        }

        public static bool operator !=(MinecraftVersion version1, MinecraftVersion version2)
        {
            return !(version1 == version2);
        }

        #endregion
    }
}
