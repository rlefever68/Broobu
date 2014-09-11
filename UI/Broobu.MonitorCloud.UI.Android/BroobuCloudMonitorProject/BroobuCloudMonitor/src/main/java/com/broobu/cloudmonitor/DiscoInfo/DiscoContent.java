package com.broobu.cloudmonitor.DiscoInfo;

import android.os.AsyncTask;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Helper class for providing sample content for user interfaces created by
 * Android template wizards.
 * <p>
 * TODO: Replace all uses of this class before publishing your app.
 */
public class DiscoContent {





    //-------------------------------------------------------------------------------------------
    /**
     * An array of sample (dummy) items.
     */
    public static List<DiscoInfo> ITEMS = new ArrayList<DiscoInfo>();
    public static List<CloudInfo> CLOUDS = new ArrayList<CloudInfo>();


    //-------------------------------------------------------------------------------------------
    /**
     * A map of sample (dummy) items, by ID.
     */
    public static Map<String, DiscoInfo> ITEM_MAP = new HashMap<String, DiscoInfo>();

    //-------------------------------------------------------------------------------------------
    private static void addItem(DiscoInfo item)
    {
        ITEMS.add(item);
        ITEM_MAP.put(item.Endpoint, item);
    }


    public static void addItems(DiscoInfo[] items){
        for(int i=0; i<items.length; i++)
        {
            addItem(items[i]);
        }
    }


    //-------------------------------------------------------------------------------------------
    /**
     * A dummy item representing a piece of content.
     */
    public static class DiscoInfo
    {
        public String Application;
        public String Contract;
        public String Endpoint;
        public String Host;
        public String Layer;
        public String Port;
        public String Protocol;
        public String Service;
        public String Status;

        @Override
        public String toString() {
            return Endpoint;
        }
    }

    public static class CloudInfo
    {
        public String Cloud;
    }
}
