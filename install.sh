aiur() { arg="$( cut -d ' ' -f 2- <<< "$@" )" && curl -sL https://gitlab.aiursoft.cn/aiursoft/aiurscript/-/raw/master/$1.sh | sudo bash -s $arg; }
wcs_path="/opt/apps/wcsApp"

install_wcs()
{
    port=$(aiur network/get_port) && echo "Using internal port: $port"
    aiur network/enable_bbr
    aiur install/caddy
    aiur install/dotnet
    aiur git/clone_to https://gitlab.aiursoft.com/aiursoft/wingetcommunityserver ./wcs
    aiur dotnet/publish $wcs_path ./wcs/src/WingetCommunityServer.csproj
    aiur services/register_aspnet_service "wcs" $port $wcs_path "wcs"
    aiur caddy/add_proxy $1 $port

    echo "Successfully installed wcs as a service in your machine! Please open $1 to try it now!"
    rm ./wcs -rf
}

# Example: install_wcs http://wcs.local
install_wcs "$@"