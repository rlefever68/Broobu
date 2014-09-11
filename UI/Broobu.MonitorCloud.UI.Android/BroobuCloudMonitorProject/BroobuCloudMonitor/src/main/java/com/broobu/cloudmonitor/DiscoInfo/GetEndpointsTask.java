package com.broobu.cloudmonitor.DiscoInfo;

import android.os.AsyncTask;

import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;
import org.springframework.web.client.RestTemplate;


import java.io.BufferedInputStream;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.Arrays;
import java.util.List;

/**
 * Created by ON8RL on 1/18/14.
 */
public class GetEndpointsTask extends AsyncTask<Void,Void,DiscoContent.DiscoInfo[]> {

    //--------------------------------------------------------------------------
    @Override
    protected DiscoContent.DiscoInfo[] doInBackground(Void... voids) {
        String urlString="http://www.broobu.com/services/broobu/cloudmon/cloudmon.svc/getendpoints"; // URL to call
        try
        {
            RestTemplate restTemplate = new RestTemplate();
            restTemplate.getMessageConverters().add(new MappingJackson2HttpMessageConverter());
            return restTemplate.getForObject(urlString, DiscoContent.DiscoInfo[].class);
        } catch (Exception e ) {
            System.out.println(e.getMessage());
            return null;
        }
    }

    //--------------------------------------------------------------------------
    @Override
    protected void onPostExecute(DiscoContent.DiscoInfo[] result) {
        DiscoContent.addItems(result);
    }
    




}