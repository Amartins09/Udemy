var gulp = require('gulp');
var concat = require('gulp-concat');
var cssmin = require('gulp-cssmin');
var uncss = require('gulp-uncss');
var browser = require('browser-sync').create();

gulp.task('browser', function(){
    browser.init({
        proxy: 'localhost:5000'
    })

    gulp.watch('./styles/*.css', ['css']);

    gulp.watch('./js/*.js', ['js']);
})

gulp.task('js', function(){
    return gulp.src([
        './node_modules/bootstrap/dist/js/bootstrap.min.js',
        './node_modules/jquery/dist/jquery.min.js',
        './js/site.js'
    ])
    .pipe(gulp.dest('wwwroot/js/'))
    .pipe(browser.stream());
});

gulp.task('css', function(){
    return gulp.src([
        './styles/site.css',
        './node_modules/bootstrap/dist/css/bootstrap.css',
    ])
    .pipe(concat('site.min.css'))
    .pipe(cssmin())
    .pipe(uncss({html: ['Views/**/*.cshtml']}))
    .pipe(gulp.dest('wwwroot/css/'))
    .pipe(browser.stream());
});

gulp.task('watch-css', function(){
    gulp.watch('./styles/*.css', ['css']);
});

gulp.task('watch-js', function(){
    gulp.watch('./js/*.js', ['js']);
});
