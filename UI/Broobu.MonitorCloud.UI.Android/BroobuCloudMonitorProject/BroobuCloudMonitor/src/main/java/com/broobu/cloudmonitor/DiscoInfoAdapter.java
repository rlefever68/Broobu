package com.broobu.cloudmonitor;

import android.app.Activity;
import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

import com.broobu.cloudmonitor.DiscoInfo.DiscoContent;

import java.util.ArrayList;

/**
 * Created by ON8RL on 1/19/14.
 */
public class DiscoInfoAdapter extends ArrayAdapter<DiscoContent.DiscoInfo>{


    private Activity context;
    private ArrayList<DiscoContent.DiscoInfo> discoItems = null;


    //----------------------------------------------------------------------------------------------
    public DiscoInfoAdapter(Activity context, int resource, ArrayList<DiscoContent.DiscoInfo> data) {
        super(context, resource, data);
        this.context = context;
        this.discoItems = data;
    }



    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        return super.getView(position, convertView, parent);
    }

    @Override
    public View getDropDownView(int position, View convertView, ViewGroup parent) {
        View row = convertView;

        /*
        if (row == null) {
            LayoutInflater inflater = context.getLayoutInflater();
            row = inflater.inflate(R.layout.simple_spinner_item, parent, false);
        }

        Country item = data.get(position);

        if (item != null) { // Parse the data from each object and set it.
            TextView CountryId = (TextView) row.findViewById(R.id.item_id);
            TextView CountryName = (TextView) row.findViewById(R.id.item_value);
            if (CountryId != null) {
                CountryId.setText(item.getId());
            }
            if (CountryName != null) {
                CountryName.setText(item.getName());
            }

        }*/

        return row;
    }


}
