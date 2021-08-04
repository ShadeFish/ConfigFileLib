# ConfigFileLib
Simple Class to manage config file</br>

'''
ConfigFile configFile = new ConfigFile("config.cfg");
// Set or create new key with value
configFile.SetValue("version","10.0.0");
// Read key value
string ver_ = configFile.ReadValue("version");
'''
