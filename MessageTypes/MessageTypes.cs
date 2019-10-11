using System;
using System.IO;

namespace MessageTypes
{
    enum MessageType
    {
        userMessage,
        userInitMessage,
        createNewUserMsg
    }

    public abstract class Msg
    {
        public Msg() { mID = 0; }
        public int mID;

        public abstract MemoryStream WriteData();
        public abstract void ReadData(BinaryReader read);

        public static Msg DecodeStream(BinaryReader read)
        {
            int id;
            Msg m = null;

            id = read.ReadInt32();

            switch (id)
            {
                case ActionMsg.ID:
                    m = new ActionMsg();
                    break;

                case UserInitMsg.ID:
                    m = new UserInitMsg();
                    break;

                case LoginMsg.ID:
                    m = new LoginMsg();
                    break;

                case CreateNewUserMsg.ID:
                    m = new CreateNewUserMsg();
                    break;

                default:
                    throw (new Exception());
            }

            if (m != null)
            {
                m.mID = id;
                m.ReadData(read);
            }

            return m;
        }
    }

    public class ClientNameMsg : Msg
    {
        public const int ID = 1;

        public String name;

        public ClientNameMsg() { mID = ID; }

        public override MemoryStream WriteData()
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter write = new BinaryWriter(stream);
            write.Write(ID);
            write.Write(name);

            write.Close();

            return stream;
        }

        public override void ReadData(BinaryReader read)
        {
            name = read.ReadString();
        }
    }

    public class ActionMsg : Msg
    {
        public const int ID = 2;
        public String msg;
        public String destination;

        public ActionMsg()
        {
            mID = ID;
        }
        public override MemoryStream WriteData()
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter write = new BinaryWriter(stream);
            write.Write(ID);
            write.Write(msg);
            //write.Write(destination);

            write.Close();

            return stream;
        }

        public override void ReadData(BinaryReader read)
        {
            msg = read.ReadString();
            destination = read.ReadString();
        }
    }

    public class UserInitMsg : Msg
    {
        public const int ID = 3;
        public String msg;

        public UserInitMsg()
        {
            mID = ID;
        }
        public override MemoryStream WriteData()
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter write = new BinaryWriter(stream);
            write.Write(ID);
            write.Write(msg);

            write.Close();

            return stream;
        }

        public override void ReadData(BinaryReader read)
        {
            msg = read.ReadString();
        }
    }

    public class CreateNewUserMsg : Msg
    {
        public const int ID = 4;
        public String msg;

        public CreateNewUserMsg() { mID = ID; }
        public override MemoryStream WriteData()
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter write = new BinaryWriter(stream);
            write.Write(ID);
            write.Write(msg);

            write.Close();

            return stream;
        }
        public override void ReadData(BinaryReader read)
        {
            msg = read.ReadString();
        }
    }

    public class LoginMsg : Msg
    {
        public const int ID = 5;
        public String msg;

        public LoginMsg() { mID = ID; }
        public override MemoryStream WriteData()
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter write = new BinaryWriter(stream);
            write.Write(ID);
            write.Write(msg);

            write.Close();

            return stream;
        }
        public override void ReadData(BinaryReader read)
        {
            msg = read.ReadString();
        }
    }

    public class LogoutMsg : Msg
    {
        public const int ID = 6;
        public String msg;

        public LogoutMsg() { mID = ID; }
        public override MemoryStream WriteData()
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter write = new BinaryWriter(stream);
            write.Write(ID);
            write.Write(msg);

            write.Close();

            return stream;
        }
        public override void ReadData(BinaryReader read)
        {
            msg = read.ReadString();
        }
    }
}