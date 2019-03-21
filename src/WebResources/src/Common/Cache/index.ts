export namespace Cache {
    let cache: { [key: string]: string } = {};

    export function get(key: string): any | null {
        let item: string | null;

        if (typeof sessionStorage !== 'undefined') {
            item = sessionStorage.getItem(key);
        } else {
            item = cache[key];
        }

        if (typeof item !== 'undefined' && item !== null) {
            return JSON.parse(item);
        }

        return null;
    }

    export function set(key: string, item: any): void {
        let itemString = JSON.stringify(item);

        if (typeof sessionStorage !== 'undefined') {
            sessionStorage.setItem(key, itemString);
        } else {
            cache[key] = itemString;
        }
    }

    export function remove(key: string): void {
        if (typeof sessionStorage !== 'undefined') {
            sessionStorage.removeItem(key);
        } else {
            delete cache[key];
        }
    }
}