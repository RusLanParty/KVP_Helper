using CitizenFX.Core.Native;
namespace KVP_Helper
{
    internal class Settings
    {        

        // GETTERS
        public static string Get(string key, string defaultValue)
        {
            string res = Function.Call<string>(Hash.GET_RESOURCE_KVP_STRING, key);
            if(res == null)
            {
                Function.Call(Hash.SET_RESOURCE_KVP, key, defaultValue);
                return defaultValue;
            }
            else
            {
                return res;
            }            
        }
        public static int Get(string key, int defaultValue)
        {
            if (KeyExists(key))
            {
                return Function.Call<int>(Hash.GET_RESOURCE_KVP_INT, key);
            }

            else
            {
                return defaultValue;
            }           
        }
        public static float Get(string key, float defaultValue)
        {
            if (KeyExists(key))
            {
                return Function.Call<float>(Hash.GET_RESOURCE_KVP_FLOAT, key);
            }

            else
            {
                return defaultValue;
            }            
        }
        public static bool Get(string key, bool defaultValue)
        {                        
            string res = Function.Call<string>(Hash.GET_RESOURCE_KVP_STRING, key);

            if(res == "true")
            {
                return true;
            }
            else if(res == "false")
            {
                return false;
            }

            // Default value
            else
            {
                string value = "false";
                if(defaultValue == true)
                {
                    value = "true";
                }
                else
                {
                    value = "false";
                }

                Function.Call(Hash.SET_RESOURCE_KVP, key, value);
                return defaultValue;
            }
        }

        // SETTERS
        public static void Set(string key, string value)
        {
            Function.Call(Hash.SET_RESOURCE_KVP, key, value);
        }
        public static void Set(string key, int value)
        {
            Function.Call(Hash.SET_RESOURCE_KVP_INT, key, value);
        }
        public static void Set(string key, float value)
        {
            Function.Call(Hash.SET_RESOURCE_KVP_FLOAT, key, value);
        }
        public static void Set(string key, bool value)
        {
            if (value)
            {
                Function.Call(Hash.SET_RESOURCE_KVP, key, "true");
            }
            else
            {
                Function.Call(Hash.SET_RESOURCE_KVP, key, "false");
            }
        }

        // PRIVATE
        private static bool KeyExists(string key)
        {
            int findHandle = Function.Call<int>(Hash.START_FIND_KVP, key);                        
            string foundName = Function.Call<string>(Hash.FIND_KVP, findHandle);            
            Function.Call(Hash.END_FIND_KVP, findHandle);

            if(foundName == null)
            {
                return false;
            }
            else
            {
                return true;
            }            
        }
    }
}
