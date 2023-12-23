#include <bits/stdc++.h>
using namespace std;
#define ll long long

ll highestPowerof2(unsigned int n)
{
    ll curr;
    ll res = 1;
    // Try all powers starting from 2^1
    for (int i = 0; i < 8 * sizeof(unsigned int); i++) {
        curr = 1 << i;
        // If current power is more than n, break
        if (curr > n)
            break;
        res = curr;
    }
    return res;
}

int solve(ll n, ll x){
         ll nearest,cur_num=n,p,q,k=0;
        
        if(n==1) q=1;
    
        while(cur_num>1){
        
            nearest = highestPowerof2(cur_num) ;
            q= (cur_num%nearest);
            p=int(log2(nearest));
                
            if(p%2==0) k+=2;
            else k++;
            
            cur_num=q;
        }
    
    if(q==1) k++;
    
    if(q<=x)
        return k;
    else
        return -1;
}

int main()
{

    int t;
    cin >> t;
    while(t--){
        ll n,x;
        cin >> n >> x;
        
    cout << solve(n,x) << endl ;
        
    }

}
