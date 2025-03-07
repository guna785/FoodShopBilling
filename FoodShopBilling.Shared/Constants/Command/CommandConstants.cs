using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FoodShopBilling.Shared.Constants.Command
{
    public static class CommandConstants
    {
        public const string DeviceRestartCommand = "C:UniqueId:REBOOT\n";

        public static string AddUserFaceCommand(string userId, string bioId, string size, byte[] data) => string.Concat(
                                                         "C:UniqueId:DATA UPDATE BIOPHOTO PIN=",
                                                          userId,
                                                         "\tFileName=",
                                                          userId,
                                                         $".jpg\tType={bioId}\tSIZE={size}\tContent=",
                                                          Convert.ToBase64String(data),
                                                         "\n"
                                                        );
        public static string AddUserFingerPrintCommand(string userId, string bioId, string size, byte[] data) => string.Concat(
                                                         "C:UniqueId:DATA FP PIN=",
                                                          userId,
                                                         "\tFID=",
                                                          bioId,
                                                         "\tValid=1\tSize=",
                                                          data.Length.ToString(),
                                                         "\tTMP=",
                                                         Convert.ToBase64String(data),
                                                          "\n"
                                                       );
        public static string AddUserInfoCommand(string userId, string name, int privilage, string password, string card, string group) => string.Concat(
                                                "C:UniqueId:DATA USER PIN=",
                                                 userId,
                                                "\tName=",
                                                 name,
                                                "\tPri=",
                                                 privilage.ToString(),
                                                "\tPasswd=",
                                                 password,
                                                "\tCard=",
                                                 card,
                                                "\tGrp=",
                                                 group,
                                                 "\tExpires=0",
                                                "\n"
                                            );
        public static string DeleteUserCommand(string userId) => string.Concat("C:UniqueId:DATA DEL_USER PIN=", userId, "\n");
        public static string BlockUnBlockUser(string userId, string name, bool isActive) => string.Concat("C:UniqueId:DATA UPDATE USERINFO PIN=", userId, "\tName=", name, isActive ? "\tGrp=1\n" : "\tGrp=100\n");
    }
}
