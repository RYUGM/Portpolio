package com.example.ij_ryu_jsp.filter;

import javax.servlet.*;
import java.io.IOException;




public class CharSetEncoding implements Filter {

    public void init(FilterConfig fConfig) throws  ServletException {

    }


    public void destroy() {
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws ServletException, IOException {
        request.setCharacterEncoding("utf-8");
        response.setCharacterEncoding("utf-8");

        chain.doFilter(request, response);

    }
}
